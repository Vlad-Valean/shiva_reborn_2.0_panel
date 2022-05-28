import { Component, OnInit } from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";

@Component({
  selector: 'app-admin-create-users',
  templateUrl: './admin-create-users.component.html',
  styleUrls: ['./admin-create-users.component.scss']
})
export class AdminCreateUsersComponent implements OnInit {

  public form = this._formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
  })

  constructor(private _formBuilder:FormBuilder) { }

  ngOnInit(): void {
  }

}
