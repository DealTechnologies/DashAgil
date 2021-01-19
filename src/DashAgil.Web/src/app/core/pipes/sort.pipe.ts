import { Pipe, PipeTransform } from '@angular/core';
import { orderBy } from 'lodash';

@Pipe({ name: 'sortBy' })
export class SortByPipe implements PipeTransform {

  transform(value: any[], order: boolean | "asc" | "desc" = 'asc', column: string = ''): any[] {
    if (!value || !order || value.length <= 1) {
      return value;
    }

    if (!column || column === '') {
      return order == 'asc' ? value.sort() : value.sort().reverse();
    }

    return orderBy(value, [column], [order]);
  }
}
