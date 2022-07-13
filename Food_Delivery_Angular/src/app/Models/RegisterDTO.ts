

export class RegisterDTO {
    Id : number;
    Username : string;
    Password : string;
    ConfirmPassword : string;
    
    email : string;
    FullName : string;
    Adress : string;
    DateOfBirth : Date;
    UserType : string;

    constructor(username:string, password :string, conf:string, mail:string, fname : string, adress:string, date:Date, utype:string) {
        this.Id = 0;
        this.Username = username;
        this.Password = password;
        this.ConfirmPassword = conf;
        this.email = mail;
        this.FullName = fname;
        this.Adress = adress;
        this.DateOfBirth = date;
        this.UserType = utype;

    }

}