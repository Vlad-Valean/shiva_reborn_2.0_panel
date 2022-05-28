import {Component, OnInit} from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {MatSnackBar} from "@angular/material/snack-bar";
import {delay} from "rxjs";
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss']
})
export class LogInComponent implements OnInit {

  public form = this._formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  })

  constructor(private _formBuilder: FormBuilder,
              private _snackBar: MatSnackBar,
              private _router: Router,
              private _authService: AuthService) {
  }

  ngOnInit(): void {
  }

  openSnack(message: string) {
    this._snackBar.open(message, 'Close');
  }

  async submit() {
    this.form.markAllAsTouched();
    if (!this.form.valid) {
      this.openSnack('Check the form before submitting.');
      return;
    }
    try {
      await this._authService.login(this.form.value);
      await delay(1000);
      const session = await this._authService.getSession();
      await this._router.navigate(session.role === 'Admin' ? ['admin'] : ['map']);
      this.openSnack('Logged in successfully!');
    } catch (e) {
      this.openSnack(`${e}`);
    }
  }

}
