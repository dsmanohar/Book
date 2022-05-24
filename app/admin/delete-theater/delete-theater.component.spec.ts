import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteTheaterComponent } from './delete-theater.component';

describe('DeleteTheaterComponent', () => {
  let component: DeleteTheaterComponent;
  let fixture: ComponentFixture<DeleteTheaterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteTheaterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteTheaterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
