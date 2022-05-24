import { Component, OnInit } from '@angular/core'
import { HttpClient } from '@angular/common/http'
@Component({
  selector: 'app-add-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.scss'],
})
export class AddMovieComponent implements OnInit {
  public name: string = ''
  public language: string = ''
  public releasedOn: Date | null = null
  public imagePath: string = ''
  public isdeleted: boolean = true
  constructor(private http: HttpClient) {}

  ngOnInit(): void {}
  insert() {
    let data = {
      name: this.name,
      language: this.language,
      isdeleted: true,
      imagepath: this.imagePath,
      releaseOn: this.releasedOn,
    }
    this.http
      .post('https://localhost:7230/api/Movies/PostUser', data)
      .subscribe((data) => {
        alert('inserted theater')
      })
  }
}
