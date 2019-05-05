import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './components/app.component';
import { ClientListComponent } from './components/client-list.component';
import { TaskEditComponent } from './components/task-edit.component';
import { NotFoundComponent } from './components/not-found.component';
import { TaskCreateComponent } from './components/task-create.component';
import { TaskFormComponent } from './components/task-form.component';

import { DataService } from './data.service';

const appRoutes: Routes = [
    { path: '', component: ClientListComponent },
    { path: 'create/:id', component: TaskCreateComponent },
    { path: 'edit/:id', component: TaskEditComponent },
    { path: '**', component: NotFoundComponent }
];

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, ClientListComponent, TaskCreateComponent, TaskEditComponent,
        TaskFormComponent, NotFoundComponent],
    providers: [DataService], 
    bootstrap: [AppComponent]
})
export class AppModule { }