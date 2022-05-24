import { Component, OnInit } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'
import { Helper } from '../helpers.Service'
class validation {
  emailValidate(param: string) {
    let regExp = /^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9-]+[.][a-zA-Z]+[.a-zA-Z]*$/
    return regExp.test(param) ? true : false
  }
  countValidate(param: string) {
    return param.length > 0
  }
}
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  constructor(
    private http: HttpClient,
    private router: Router,
    public helper: Helper,
  ) {}
  public email: string = ''
  public pwd: string = ''
  ngOnInit(): void {}
  login() {
    let data = { email: "dsmanohar222@gmail.com", password: "ds123456@+" }
    this.http
      .post('https://localhost:7230/api/Users/CheckUser', data)
      .subscribe((data) => {
        if (data == null) {
          alert('wrong details')
          return
        }
        this.helper.userLogged = data
        this.router.navigate(['/'])
      })
    return true
  }
}
