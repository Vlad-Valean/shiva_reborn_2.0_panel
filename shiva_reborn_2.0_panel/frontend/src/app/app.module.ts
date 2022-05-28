import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppComponent} from './app.component';
import {AppRoutingModule} from "./app-routing.component";
import {LogInComponent} from './pages/log-in/log-in.component';
import {RouterModule} from "@angular/router";
import {MenuComponent} from "./components/menu/menu.component";
import {MatFormFieldModule} from "@angular/material/form-field";
import {ReactiveFormsModule} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {MatButtonModule} from "@angular/material/button";
import {MapComponent} from './components/map/map.component';
import {DialogContentComponent} from './components/dialog-content/dialog-content.component';
import {MatDialogModule} from "@angular/material/dialog";
import{MatSnackBarModule} from "@angular/material/snack-bar";
import{HttpClientModule} from "@angular/common/http";
import { CalendarComponent } from './components/calendar/calendar.component';
import {MatAutocompleteModule} from "@angular/material/autocomplete";

@NgModule({
  declarations: [
    AppComponent,
    LogInComponent,
    MenuComponent,
    MapComponent,
    DialogContentComponent,
    CalendarComponent
  ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        AppRoutingModule,
        RouterModule,
        MatFormFieldModule,
        ReactiveFormsModule,
        MatInputModule,
        MatButtonModule,
        MatDialogModule,
        MatSnackBarModule,
        HttpClientModule,
        MatAutocompleteModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
