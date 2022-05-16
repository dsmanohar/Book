import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router'
import { Helper } from '../helpers.Service'
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  constructor(private router: Router, public helper: Helper) {}
  ngOnInit(): void {}
  changeRoute() {
    this.router.navigate(['/login'])
  }
  sendFilter(language: string) {
    this.helper.changeLanguage(language)
  }
  logout() {
    this.helper.userLogged = null
    this.router.navigate(['/'])
  }
}
