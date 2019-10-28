using MultiCheat_Window.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MultiCheat_Window.Update
{
    class UpdateChecker
    {
        private UpdateWebClient client;
        private string urlFirst, urlSecond;
        private int versionFirst = -1, versionSecond = -1, newestVersionIndex = -1;
        private string[] dataFirst, dataSecond;

        public UpdateChecker(string updateUrlFirst, string updateUrlSecond, string versionFileName)
        {
            urlFirst = updateUrlFirst + versionFileName;
            urlSecond = updateUrlSecond + versionFileName;
        }

        public CheckerGlobalErrorType CheckUpdate()
        {
            CheckerErrorType first_err = DownloadUpdateData(1);
            CheckerErrorType second_err = DownloadUpdateData(2);
            if (first_err == CheckerErrorType.LOAD_ERROR && second_err == CheckerErrorType.LOAD_ERROR)
                return CheckerGlobalErrorType.LOAD_ERROR_BOTH;
            if (first_err == CheckerErrorType.CONTENT_ERROR && second_err == CheckerErrorType.CONTENT_ERROR)
                return CheckerGlobalErrorType.CONTENT_ERROR_BOTH;
            if ((first_err == CheckerErrorType.LOAD_ERROR && second_err == CheckerErrorType.CONTENT_ERROR) || (first_err == CheckerErrorType.CONTENT_ERROR && second_err == CheckerErrorType.LOAD_ERROR))
                return CheckerGlobalErrorType.DIFFERENT_ERRORS;
            if ((first_err == CheckerErrorType.LOAD_ERROR && second_err == CheckerErrorType.NONE) || (first_err == CheckerErrorType.NONE && second_err == CheckerErrorType.LOAD_ERROR))
                return CheckerGlobalErrorType.LOAD_ERROR_ONCE;
            if ((first_err == CheckerErrorType.CONTENT_ERROR && second_err == CheckerErrorType.NONE) || (first_err == CheckerErrorType.NONE && second_err == CheckerErrorType.CONTENT_ERROR))
                return CheckerGlobalErrorType.CONTENT_ERROR_ONCE;
            return CheckerGlobalErrorType.NONE;
        }
        
        private CheckerErrorType DownloadUpdateData(int urlIndex)
        {
            client = new UpdateWebClient();
            byte[] updateData;
            try
            {
                updateData = client.DownloadData(urlIndex == 1 ? urlFirst : urlSecond);
                client.Dispose();
            }
            catch (Exception)
            {
                return CheckerErrorType.LOAD_ERROR;
            }
            string updateDataStr = Encoding.Default.GetString(updateData);
            string[] data = updateDataStr.Split('/');
            int version;
            if (string.IsNullOrEmpty(data[0]) || !int.TryParse(data[0].ToString(), out version))
                return CheckerErrorType.CONTENT_ERROR;
            if (urlIndex == 1)
            {
                versionFirst = version;
                dataFirst = data;
            }
            else
            {
                versionSecond = version;
                dataSecond = data;
            }
            return CheckerErrorType.NONE;
        }

        public int GetNewestVersion()
        {
            if (versionFirst == -1 && versionSecond == -1)
                return -1;
            if (versionFirst >= versionSecond)
            {
                newestVersionIndex = 1;
                return versionFirst;
            } 
            else
            {
                newestVersionIndex = 2;
                return versionSecond;
            }
                
        }

        public string GetNewestUpdateUrl()
        {
            if (newestVersionIndex == -1)
                return null;
            if (newestVersionIndex == 1)
                return Constants.updateUrlFirst + dataFirst[1];
            else
                return Constants.updateUrlSecond + dataSecond[1];
        }
    }

    partial class UpdateWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = Constants.updateTimeout;
            return w;
        }
    }
    enum CheckerErrorType
    {
        LOAD_ERROR, CONTENT_ERROR, NONE
    }

    enum CheckerGlobalErrorType
    {
        LOAD_ERROR_BOTH, CONTENT_ERROR_BOTH, DIFFERENT_ERRORS, LOAD_ERROR_ONCE, CONTENT_ERROR_ONCE, NONE
    }
}