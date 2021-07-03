using System;
using System.Collections.Generic;
using System.Text;

namespace domain.extensions.Core.Result
{

  public class Result<T>
  {

    public readonly T Value;
    public readonly string Error;

    Result(T v = default, string e = default)
    {
      Value = v;
      Error = e;
    }

    public bool IsSuccess => string.IsNullOrEmpty(Error);

    public T Unwrap() => !IsSuccess 
      ? throw new OperationException(Error)
      : Value;


    // --- Builders ------------------------------------------------------------
    public static Result<T> OK(T value) => new Result<T>(v: value);

    public static Result<T> FAIL(string error) => new Result<T>(e: error);

  }

}
