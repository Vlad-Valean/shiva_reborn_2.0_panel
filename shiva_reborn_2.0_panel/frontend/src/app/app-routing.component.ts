import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {LogInComponent} from "./pages/log-in/log-in.component";
import {MapPageComponent} from "./pages/map-page/map-page.component";


const routes: Routes = [
  {path:'login',component:LogInComponent},
  {path:'',redirectTo:'/login',pathMatch:'full'},
  {path:'map',component:MapPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
