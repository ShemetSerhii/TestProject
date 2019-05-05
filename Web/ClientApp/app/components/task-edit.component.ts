import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../data.service';
import { Task } from '../models/task';

@Component({
    templateUrl: '../templates/task-edit.component.html'
})
export class TaskEditComponent implements OnInit {

    id: number;
    task: Task;    
    loaded: boolean = false;

    constructor(private dataService: DataService, private router: Router, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        if (this.id)
            this.dataService.getTask(this.id)
                .subscribe((data: Task) => {
                    this.task = data;
                    if (this.task != null) this.loaded = true;
                });
    }

    save() {
        this.dataService.updateTask(this.task).subscribe(data => this.router.navigateByUrl("/"));
    }
}