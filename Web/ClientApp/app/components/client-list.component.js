var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input, ElementRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataService } from '../data.service';
var ClientListComponent = /** @class */ (function () {
    function ClientListComponent(dataService, elementRef, route) {
        this.dataService = dataService;
        this.elementRef = elementRef;
        this.route = route;
        this.taskStatus = false;
        this.element = elementRef;
    }
    ClientListComponent.prototype.ngOnInit = function () {
        this.load();
    };
    ClientListComponent.prototype.load = function () {
        var _this = this;
        this.dataService.getClients().subscribe(function (data) { return _this.clients = data; });
    };
    ClientListComponent.prototype.showTasks = function (id) {
        var _this = this;
        if (id != this.id) {
            this.id = id;
            this.taskStatus = true;
            this.dataService.getTasks(id).subscribe(function (data) { return _this.loadTasks = data; });
            this.tasks = this.loadTasks;
        }
        else {
            this.id = 0;
            this.taskStatus = false;
        }
    };
    ClientListComponent.prototype.delete = function (id) {
        var _this = this;
        var clientId = this.id;
        this.id = 0;
        this.dataService.deleteTask(id).subscribe(function (data) { return _this.showTasks(clientId); });
    };
    ClientListComponent.prototype.mouseEnter = function () {
        this.element.nativeElement.style.cursor = "pointer";
    };
    ClientListComponent.prototype.mouseLeave = function () {
        this.element.nativeElement.style.cursor = "default";
    };
    ClientListComponent.prototype.onKey = function () {
        var _this = this;
        this.tasks = this.loadTasks.filter(function (Client) { return Client.name.indexOf(_this.firstName) === 0; });
    };
    __decorate([
        Input(),
        __metadata("design:type", Number)
    ], ClientListComponent.prototype, "id", void 0);
    ClientListComponent = __decorate([
        Component({
            templateUrl: '../templates/client-list.component.html',
            styles: [" \n            .tables{display:flex;}\n            table{margin:13px;}          \n    "]
        }),
        __metadata("design:paramtypes", [DataService, ElementRef, ActivatedRoute])
    ], ClientListComponent);
    return ClientListComponent;
}());
export { ClientListComponent };
//# sourceMappingURL=client-list.component.js.map