import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {LogInComponent} from "./pages/log-in/log-in.component";
import {MenuComponent} from "./components/menu/menu.component";


const routes: Routes = [
  {path:'login',component:LogInComponent},
  {path:'',redirectTo:'/login',pathMatch:'full'},
  {path:'map',component:MenuComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
