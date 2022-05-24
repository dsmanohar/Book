import { Component, OnInit } from '@angular/core'

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
})
export class AdminComponent implements OnInit {
  public deleteMovie: boolean = false
  public deleteTheater: boolean = false
  public insertMovie: boolean = false
  public insertTheater: boolean = false
  constructor() {}

  ngOnInit(): void {}
  clickFunc(id: number) {
    this.deleteMovie = false
    this.deleteTheater = false
    this.insertMovie = false
    this.insertTheater = false
    if (id === 1) this.insertMovie = true
    else if (id === 2) this.deleteMovie = true
    else if (id == 3) this.insertTheater = true
    else this.deleteTheater = true
  }
}
