import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { TestErrorComponent } from './errors/test-error/test-error.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { authGuard } from './_guard/auth.guard';

const routes: Routes = [
  {path: '',component:HomeComponent},
  {path: '' ,
  runGuardsAndResolvers:'always',
  canActivate:[authGuard],
  children:[
    {path:'lists',component:ListsComponent},
    {path:'members',component:MemberListComponent},
    {path:'member/:id',component:MemberDetailComponent},
    {path:'messages',component:MessagesComponent}
  ] 
  },
  {path:'errors',component:TestErrorComponent},
  {path:'not-found',component:NotFoundComponent},
  {path:'server-error',component:ServerErrorComponent},
  {path:'**',component:NotFoundComponent,pathMatch:'full'} // ensure that this wildcard route only matches 
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
