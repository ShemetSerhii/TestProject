import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../data.service';
import { Task } from '../models/task';

@Component({
    templateUrl: '../templates/task-create.component.html'
})
export class TaskCreateComponent {

    id: number;
    task: Task = new Task();    

    constructor(private dataService: DataService, private router: Router, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    save() {
        this.dataService.createTask(this.id, this.task).subscribe(data => this.router.navigateByUrl("/"));
    }
}