import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-radar-items',
  templateUrl: './radar-items.component.html',
  styleUrls: ['./radar-items.component.scss']
})
export class RadarItemsComponent implements OnInit {

  @Input() type: number;
  @Input() series: any[] = [];

  @Output() change: EventEmitter<any> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  changeValue(serie: any) {
    this.change.emit(serie);
  }
}
