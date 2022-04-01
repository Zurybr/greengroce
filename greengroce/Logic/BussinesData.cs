using System;
using Microsoft.AspNetCore.Mvc;
using greengroce.Models;

namespace greengroce.Logic
{
    public class BussinesData 
    {
        public AppDbContext dbContext { get; set; }
        public FaultException FaultException { get; set; }

        public BussinesData()
        {
            dbContext = new AppDbContext();
        }

        public String GetException(Int32 ErrorCode, String SystemException)
        {
            FaultException = new FaultException();
            FaultException.SetException(ErrorCode, SystemException);
            return FaultException.ToString();
        }
    }
}