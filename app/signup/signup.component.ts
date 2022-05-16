import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router'
import { HttpClient } from '@angular/common/http'
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
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent implements OnInit {
  constructor(private router: Router, private http: HttpClient) {}
  name: string = ''
  email: string = ''
  phoneno: string = ''
  password: string = ''
  ngOnInit(): void {}
  postNewUser() {
    let validator = new validation()
    if (
      !validator.emailValidate(this.email) ||
      !validator.countValidate(this.name) ||
      !validator.countValidate(this.password)
    ) {
      alert('Invalid Details')
      return false
    }
    let data = {
      name: this.name,
      email: this.email,
      phoneno: this.phoneno.toString(),
      password: this.password,
    }
    this.http
      .post('https://localhost:7230/api/Users/PostUser', data)
      .subscribe((data) => {
        if (data === null) {
          alert('user exits')
          return
        }
        console.log(data)
        this.router.navigate(['/login'])
      })
    return true
  }
}
