import { Component, OnInit, Input, ElementRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataService } from '../data.service';
import { Client } from '../models/client';
import { Task } from '../models/task';

@Component({
    templateUrl: '../templates/client-list.component.html',
    styles: [` 
            .tables{display:flex;}
            .tables-item{margin:13px;}        
    `]
})

export class ClientListComponent implements OnInit {
    @Input() id: number;

    clients: Client[];
    loadClients: Client[];
    cities: string[];
    tasks: Task[];
    taskStatus: boolean = false;

    firstName: string;
    filterCity: string;

    element: ElementRef;

    constructor(private dataService: DataService, private elementRef: ElementRef, private route: ActivatedRoute) {
        this.element = elementRef;
    }

    ngOnInit() {
        this.load();
    }

    load() {
        this.dataService.getClients().subscribe((data: Client[]) => {
            this.clients = data;
            this.loadClients = data;
            this.cities = Array.from(new Set(this.clients.map(client => client.address)));
        });
    }

    showTasks(id: number) {
        if (id != this.id) {
            this.id = id;
            this.taskStatus = true;
            this.dataService.getTasks(id).subscribe((data: Task[]) => this.tasks = data);
        } else {
            this.id = 0;
            this.taskStatus = false;
        }
    }

    delete(id: number) {
        let clientId = this.id;
        this.id = 0;
        this.dataService.deleteTask(id).subscribe(data => this.showTasks(clientId));
    }

    mouseEnter() {
        this.element.nativeElement.style.cursor = "pointer";
    }

    mouseLeave() {
        this.element.nativeElement.style.cursor = "default";
    }

    onKey() {
        this.clients = this.loadClients.filter(
                client => client.firstName.toLowerCase().indexOf(this.firstName.toLowerCase()) === 0);             
    }

    onFilter(filterVal: any) {
        if (filterVal == "0") {
            this.clients = this.loadClients.map(client => client);
            this.onKey();
        } else {
            this.filterCity = filterVal;
            this.clients = this.loadClients.filter(
                client => client.address == filterVal);
        }           
    }
}