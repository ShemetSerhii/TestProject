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
var TaskEditComponent = /** @class */ (function () {
    function TaskEditComponent(dataService, router, activeRoute) {
        this.dataService = dataService;
        this.router = router;
        this.loaded = false;
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }
    TaskEditComponent.prototype.ngOnInit = function () {
        var _this = this;
        if (this.id)
            this.dataService.getTask(this.id)
                .subscribe(function (data) {
                _this.task = data;
                if (_this.task != null)
                    _this.loaded = true;
            });
    };
    TaskEditComponent.prototype.save = function () {
        var _this = this;
        this.dataService.updateTask(this.task).subscribe(function (data) { return _this.router.navigateByUrl("/"); });
    };
    TaskEditComponent = __decorate([
        Component({
            templateUrl: '../templates/task-edit.component.html'
        }),
        __metadata("design:paramtypes", [DataService, Router, ActivatedRoute])
    ], TaskEditComponent);
    return TaskEditComponent;
}());
export { TaskEditComponent };
//# sourceMappingURL=task-edit.component.js.map