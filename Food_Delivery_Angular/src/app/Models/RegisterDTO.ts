

export class RegisterDTO {
    id : number;
    username : string;
    password : string;
    confirmPassword : string;
    
    email : string;
    fullName : string;
    adress : string;
    doB : Date;
    userType : string;
    isVerified : boolean;

    constructor(username:string, password :string, conf:string, mail:string, fname : string, adress:string, date:Date, utype:string, ver:boolean) {
        this.id = 0;
        this.username = username;
        this.password = password;
        this.confirmPassword = conf;
        this.email = mail;
        this.fullName = fname;
        this.adress = adress;
        this.doB = date;
        this.userType = utype;
        this.isVerified = ver;

    }

}