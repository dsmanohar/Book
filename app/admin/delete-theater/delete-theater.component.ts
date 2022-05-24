import { Component, OnInit } from '@angular/core'
import { HttpClient } from '@angular/common/http'
@Component({
  selector: 'app-delete-theater',
  templateUrl: './delete-theater.component.html',
  styleUrls: ['./delete-theater.component.scss'],
})
export class DeleteTheaterComponent implements OnInit {
  public movieId: number = 0
  constructor(private http: HttpClient) {}

  ngOnInit(): void {}
  delete() {
    this.http
      .delete(
        'https://localhost:7230/api/Theaters/DeleteTheater/' + this.movieId,
      )
      .subscribe((data) => {
        alert('movie deleted')
      })
  }
}
