using System;
using Newtonsoft.Json;
using greengroce.Models;

namespace greengroce.Logic
{ 
    public class FaultException
    {
        public Int32 FaultCode { get; set; }
        public String FaultDescription { get; set; }
        public String SystemException { get; set; }
       

        public FaultException()
        {
            FaultCode = 0;
            FaultDescription = String.Empty;
            SystemException = null;
        }

        public void SetException(Int32 ErrorCode, String SystemException)
        {
            SetException("No se ha encontrado una descripción relacionada al error " + ErrorCode.ToString() + "\n" + SystemException);
        }
        
        public void SetException(String FaultDescription)
        {
            this.FaultCode = 1000;
            this.FaultDescription = FaultDescription;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}