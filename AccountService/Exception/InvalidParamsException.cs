namespace AccountService.Exception;

public class InvalidParamsException: System.Exception{
    public int Code {get;set;}
    public InvalidParamsException(int code,string message) : base(message){
        this.Code = code;
    }
}