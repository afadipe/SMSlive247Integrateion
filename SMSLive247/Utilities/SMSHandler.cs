using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSLive247.Utilities
{
    ///---------------------------------------------------------------------------------------------
    /// <summary>
    ///   SMSHandler is a class file that integrate into SMSlive247 for send sms using http
    /// </summary>
    /// <copyright>
    /// *****************************************************************************
    ///     ----- Fadipe Wasiu Ayobami . All Rights Reserved. Copyright (c) 2017
    /// *****************************************************************************
    /// </copyright>
    /// <remarks>
    /// *****************************************************************************
    ///     ---- Created For: Public Use (All Products)
    ///     ---- Created By: Fadipe Wasiu Ayobami
    ///     ---- Original Language: C#
    ///     ---- Current Version: v1.0.0.0.1
    ///     ---- Current Language: C#
    /// *****************************************************************************
    /// </remarks>
    /// <history>
    /// *****************************************************************************
    ///     --- Date First Created : 08 - 11 - 2017
    ///     --- Author: Fadipe Wasiu Ayobami
    ///     --- Date First Reviewed: 
    ///     --- Date Last Reviewed:
    /// *****************************************************************************
    /// </history>
    /// <usage>
    /// initiate the SMSHandler.SendBulkSMSUsingSMSLive247
    /// then pass in the Receiptent phone number nad message
    /// 
    /// -- Fadipe Wasiu Ayobami
    /// </usage>
    /// ----------------------------------------------------------------------------------------------
    /// 
    public static class SMSHandler
    {
        public static Boolean SendBulkSMSUsingSMSLive247(string smsRecipient, string message)
        {
            try
            {

                var xclient = new RestClient("http://www.smslive247.com");
                var request = new RestRequest("http/index.aspx", Method.POST);
                request.AddParameter("cmd", "login", ParameterType.QueryString);
                request.AddParameter("owneremail", "parentacctusername", ParameterType.QueryString);
                request.AddParameter("subacct", "subacctusername", ParameterType.QueryString);
                request.AddParameter("subacctpwd", "subacctpassword", ParameterType.QueryString);
                IRestResponse response = xclient.Execute(request);
                var content = response.Content;
                string[] xx = content.Split(':');
                string sesionId = xx[1];

                if (sesionId != null)
                {
                    var xclient2 = new RestClient("http://www.smslive247.com");
                    var request2 = new RestRequest("http/index.aspx", Method.POST);
                    request2.AddParameter("cmd", "sendmsg", ParameterType.QueryString);
                    request2.AddParameter("sessionid", sesionId, ParameterType.QueryString);
                    request2.AddParameter("message", message, ParameterType.QueryString);
                    request2.AddParameter("sender", "SMSLIVE@$&Test", ParameterType.QueryString);
                    request2.AddParameter("sendto", smsRecipient, ParameterType.QueryString);
                    request2.AddParameter("msgtype", "0", ParameterType.QueryString);
                    IRestResponse response2 = xclient2.Execute(request2);
                    var responseString = response2.Content;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
