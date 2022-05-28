import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {LogInComponent} from "./pages/log-in/log-in.component";
import {MapPageComponent} from "./pages/map-page/map-page.component";
import {AdminPageComponent} from "./pages/admin-page/admin-page.component";


const routes: Routes = [
  {path:'login',component:LogInComponent},
  {path:'',redirectTo:'/login',pathMatch:'full'},
  {path:'map',component:MapPageComponent},
  {path:'admin', component:AdminPageComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
