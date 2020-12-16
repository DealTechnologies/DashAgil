import { Component, OnInit } from '@angular/core';
import { EChartOption } from 'echarts';
import { ChartsConfigurationService, OverviewService } from 'src/app/core/services';

import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { formatDate } from '@angular/common';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-radar-agil',
  templateUrl: './radar-agil.component.html',
  styleUrls: ['./radar-agil.component.scss'],
})

export class RadarAgilComponent implements OnInit {

  optionsRadar: EChartOption;
  taskForm: FormGroup;
  mode = new FormControl('side');
  isNewEvent = false;
  showFiller = false;
  userImg: string;
  dialogTitle: string;


  constructor(private chartsConfiguration: ChartsConfigurationService,
              private fb: FormBuilder, private snackBar: MatSnackBar) {
                this.taskForm = this.createFormGroup(null);
              }
  step = 0;



  tasks = [
    {
      id: '1',
      name: 'Entrega de valor ao cliente',
      title: 'Estamos conseguindo medir o valor para o cliente de forma Quantitativa Exemplo: Receita recorrente; anual; Receita  anual total; Receita recorrente anual por cliente; Receita  recorrente mensal; Lucro  bruto; Custo de aquisição do cliente; Evasão; Número  de usuários ativos.',
    },
    {
      id: '1',
      name: 'Entrega de valor ao cliente',
      title: 'Estamos conseguindo medir o valor para o cliente de forma Quantitativa Exemplo: Receita recorrente; anual; Receita  anual total; Receita recorrente anual por cliente; Receita  recorrente mensal; Lucro  bruto; Custo de aquisição do cliente; Evasão; Número  de usuários ativos.',
    },
    {
      id: '1',
      name: 'Entrega de valor ao cliente',
      title: 'Estamos conseguindo medir o valor para o cliente de forma Quantitativa Exemplo: Receita recorrente; anual; Receita  anual total; Receita recorrente anual por cliente; Receita  recorrente mensal; Lucro  bruto; Custo de aquisição do cliente; Evasão; Número  de usuários ativos.',
    },
    {
      id: '1',
      name: 'Entrega de valor ao cliente',
      title: 'Estamos conseguindo medir o valor para o cliente de forma Quantitativa Exemplo: Receita recorrente; anual; Receita  anual total; Receita recorrente anual por cliente; Receita  recorrente mensal; Lucro  bruto; Custo de aquisição do cliente; Evasão; Número  de usuários ativos.',
    },
    {
      id: '1',
      name: 'Entrega de valor ao cliente',
      title: 'Estamos conseguindo medir o valor para o cliente de forma Quantitativa Exemplo: Receita recorrente; anual; Receita  anual total; Receita recorrente anual por cliente; Receita  recorrente mensal; Lucro  bruto; Custo de aquisição do cliente; Evasão; Número  de usuários ativos.',
    }
  ];

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.tasks, event.previousIndex, event.currentIndex);
  }
  toggle(task, nav: any) {
    nav.close();
    task.done = !task.done;
  }
  addNewTask(nav: any) {
    this.resetFormField();
    this.isNewEvent = true;
    this.dialogTitle = 'New Task';
    this.userImg = 'assets/images/user/user1.jpg';
    nav.open();
  }
  taskClick(task, nav: any): void {
    this.isNewEvent = false;
    this.dialogTitle = 'Edit Task';
    this.userImg = task.img;
    nav.open();
    this.taskForm = this.createFormGroup(task);
  }
  closeSlider(nav: any) {
    if (nav.open()) {
      nav.close();
    }
  }
  createFormGroup(data: any) {
    return this.fb.group({
      id: [data ? data.id : this.getRandomID()],
      name: [data ? data.name : null],
      title: [data ? data.title : null]
    });
  }
  saveTask() {
    this.tasks.unshift(this.taskForm.value);
    this.resetFormField();
    this.showNotification(
      'snackbar-success',
      'Add Task Successfully...!!!',
      'bottom',
      'center'
    );
  }
  editTask() {
    const targetIdx = this.tasks
      .map((item) => item.id)
      .indexOf(this.taskForm.value.id);
    this.tasks[targetIdx] = this.taskForm.value;
    this.showNotification(
      'black',
      'Edit Task Successfully...!!!',
      'bottom',
      'center'
    );
  }
  deleteTask(nav: any) {
    const targetIdx = this.tasks
      .map((item) => item.id)
      .indexOf(this.taskForm.value.id);
    this.tasks.splice(targetIdx, 1);
    nav.close();
    this.showNotification(
      'snackbar-danger',
      'Delete Task Successfully...!!!',
      'bottom',
      'center'
    );
  }
  resetFormField() {
    this.taskForm.controls.name.reset();
    this.taskForm.controls.title.reset();
  }
  public getRandomID(): string {
    const S4 = () => {
      return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    };
    return S4() + S4();
  }



  ngOnInit() {
    this.optionsRadar = this.chartsConfiguration.radar();
  }

  showNotification(colorName, text, placementFrom, placementAlign) {
    this.snackBar.open(text, '', {
      duration: 2000,
      verticalPosition: placementFrom,
      horizontalPosition: placementAlign,
      panelClass: colorName
    });
  }

  onChartEvent(event: any, type: string) {
    alert(event.name);
  }

}
