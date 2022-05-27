import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppComponent} from './app.component';
import {AppRoutingModule} from "./app-routing.component";
import {LogInComponent} from './pages/log-in/log-in.component';
import {RouterModule} from "@angular/router";
import {MenuComponent} from "./components/menu/menu.component";

@NgModule({
  declarations: [
    AppComponent,
    LogInComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
