import { FavoritasComponent } from './components/views/favoritas/favoritas.component';
import { BibliotecaComponent } from './components/views//biblioteca/biblioteca.component';
import { CadastroMusicaComponent } from './components/views/cadastro-musica/cadastro-musica.component';
import { CriarPlaylistComponent } from './components/views/criar-playlist/criar-playlist.component';
import { CriarUsuarioComponent } from './components/views/criar-usuario/criar-usuario.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './components/views/homepage/homepage.component';


const routes: Routes = [
    { path: '', component: HomepageComponent},
    { path: 'usuario/cadastro', component: CriarUsuarioComponent},
    { path: 'musica/cadastro', component: CadastroMusicaComponent },
    { path: 'playlist/criar', component: CriarPlaylistComponent },
    { path: 'biblioteca', component: BibliotecaComponent },
    { path: 'favoritas', component: FavoritasComponent },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
