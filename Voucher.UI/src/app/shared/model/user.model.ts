export class User {
    domainName: string;
    userName: string;
    password: string;

    constructor(username: string, password: string) {
        this.userName = username;
        this.password = password;
        this.domainName = 'sede.gol.com';
    }
}
