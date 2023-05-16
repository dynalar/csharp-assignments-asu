using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NumberGuessService
{
    [ServiceContract]
    public interface INumberGuessService
    {
        // define our UriTemplate to follow this specific query string format for our restful service.
        [OperationContract]
        [WebGet(UriTemplate = "secretNumber?lower={lower}&upper={upper}", ResponseFormat = WebMessageFormat.Json)]
        int SecretNumber(int lower, int upper);

        [OperationContract]
        [WebGet(UriTemplate = "checkNumber?userNum={userNum}&secretNum={secretNum}", ResponseFormat = WebMessageFormat.Json)]
        string CheckNumber(int userNum, int secretNum);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
