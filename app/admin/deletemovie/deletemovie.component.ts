import { Component, OnInit } from '@angular/core'
import { HttpClient } from '@angular/common/http'
@Component({
  selector: 'app-deletemovie',
  templateUrl: './deletemovie.component.html',
  styleUrls: ['./deletemovie.component.scss'],
})
export class DeletemovieComponent implements OnInit {
  movieId: number = 0
  constructor(private http: HttpClient) {}

  ngOnInit(): void {}
  delete() {
    this.http
      .delete('https://localhost:7230/api/Movies/DeleteMovie/' + this.movieId)
      .subscribe((data) => {
        alert('movie deleted')
      })
  }
}
