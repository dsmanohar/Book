import { Component, OnInit } from '@angular/core'
import { Helper } from '../helpers.Service'
import { Router, ActivatedRoute } from '@angular/router'
import { HttpClient } from '@angular/common/http'
@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.scss'],
})
export class BookingComponent implements OnInit {
  theaters: { id: number; name: string }[] = []
  state: boolean = false
  curTickets: number = 0
  movieName: string = this.helper.selectedMovie;
  constructor(
    public helper: Helper,
    private router: Router,
    private http: HttpClient,
    private route: ActivatedRoute,
  ) {}
  movieId: number = this.route.snapshot.params['id']
  numberOfTickets: number = 0
  theaterId: number = 0
  showId: number = 0
  numTickets!: number
  ngOnInit(): void {
    if (this.helper.userLogged === null) this.router.navigate(['/login'])
    this.http
      .get('https://localhost:7230/api/Movies/GetMovie/' + this.movieId)
      .subscribe((data) => {
        if (data != null) this.movieName = <string>data
      })
    this.http
      .get('https://localhost:7230/api/Theaters/GetTheaters/' + this.movieId)
      .subscribe((data: any) => {
        data.forEach((element: any) => {
          this.theaters.push(element)
        })
      })
  }

  bookTicket(showId: number, theaterId: number) {
    this.http
      .get(
        'https://localhost:7230/api/Tickets/' +
          this.movieId +
          '/' +
          theaterId +
          '/' +
          showId,
      )
      .subscribe((data: any) => {
        this.curTickets = data[0]
      })
    this.state = !this.state
    this.theaterId = theaterId
    this.showId = showId
  }

  buyTicket() {
    if (this.numTickets > 6 || this.numTickets <= 0) {
      alert('invalid ticket number')
      return
    }
    this.http
      .get(
        'https://localhost:7230/api/Tickets/' +
          this.movieId +
          '/' +
          this.theaterId +
          '/' +
          this.showId +
          '/' +
          this.numTickets,
      )
      .subscribe((data) => {
        alert('tickets booked ')
        this.state = !this.state
        this.router.navigate(['/'])
      })
  }
}
