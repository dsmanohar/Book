import { Component, OnInit, Input } from '@angular/core'

@Component({
  selector: 'app-moviecard',
  templateUrl: './moviecard.component.html',
  styleUrls: ['./moviecard.component.scss'],
})
export class MoviecardComponent implements OnInit {
  @Input() inputVal!: { path: string; name: string; id: number }
  constructor() {}

  ngOnInit(): void {}
}
