import { Component, OnInit } from '@angular/core'
import { HttpClient } from '@angular/common/http'
@Component({
  selector: 'app-theater',
  templateUrl: './theater.component.html',
  styleUrls: ['./theater.component.scss'],
})
export class TheaterComponent implements OnInit {
  constructor(private http: HttpClient) {}
  public name: string = ''
  public location: string = ''
  ngOnInit(): void {}
  insert() {
    let data = { name: this.name, location: this.location, isdeleted: false }
    this.http
      .post('https://localhost:7230/api/Theaters/PostUser', data)
      .subscribe((data) => {
        alert('inserted theater')
        this.name = ''
        this.location = ''
      })
  }
}
