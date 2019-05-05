import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Task } from './models/task';

@Injectable()
export class DataService {

    private urlClient = "/api/client";
    private urlTask = "/api/task";

    constructor(private http: HttpClient) {
    }

    getClients() {
        return this.http.get(this.urlClient);
    }

    getTasks(id: number) {
        return this.http.get(this.urlClient + '/' + id);
    }

    getTask(id: number) {
        return this.http.get(this.urlTask + '/' + id);
    }

    createTask(id: number, task: Task) {
        return this.http.post(this.urlTask + '/' + id, task);
    }

    updateTask(task: Task) {
        return this.http.put(this.urlTask + '/' + task.id, task);
    }

    deleteTask(id: number) {
        return this.http.delete(this.urlTask + '/' + id);
    }
}