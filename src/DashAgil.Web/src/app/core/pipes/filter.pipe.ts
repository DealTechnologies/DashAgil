import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterSeries',
  pure: false
})
export class FilterSeriesPipe implements PipeTransform {
  transform(items: any[], type: number): any {
    if (!items) {
      return items;
    }
    return items.filter(item => item.type == type);
  }
}
