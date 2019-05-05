var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../data.service';
import { Task } from '../models/task';
var TaskCreateComponent = /** @class */ (function () {
    function TaskCreateComponent(dataService, router, activeRoute) {
        this.dataService = dataService;
        this.router = router;
        this.task = new Task();
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }
    TaskCreateComponent.prototype.save = function () {
        var _this = this;
        this.dataService.createTask(this.id, this.task).subscribe(function (data) { return _this.router.navigateByUrl("/"); });
    };
    TaskCreateComponent = __decorate([
        Component({
            templateUrl: '../templates/task-create.component.html'
        }),
        __metadata("design:paramtypes", [DataService, Router, ActivatedRoute])
    ], TaskCreateComponent);
    return TaskCreateComponent;
}());
export { TaskCreateComponent };
//# sourceMappingURL=task-create.component.js.map