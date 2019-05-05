import { Component, Input } from '@angular/core';
import { Task } from '../models/task';

@Component({
    selector: "task-form",
    templateUrl: '../templates/task-form.component.html'
})

export class TaskFormComponent {
    @Input() task: Task;
}