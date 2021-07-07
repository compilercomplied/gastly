using System;
using System.Collections.Generic;
using System.Text;

namespace domain.extensions.Core.Result
{

  public abstract class BaseError
  {
    public readonly string Message;

    protected BaseError(string error) 
    { 
      Message = error ?? Messages.Core_Error_DefaultError; 
    }

  }

  public class Error : BaseError
  {

    public Error(string message) : base(message) { }

  }

}
