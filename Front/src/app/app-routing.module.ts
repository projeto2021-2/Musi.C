import { FavoritasComponent } from './favoritas/favoritas.component';
import { BibliotecaComponent } from './biblioteca/biblioteca.component';
import { CadastroMusicaComponent } from './cadastro-musica/cadastro-musica.component';
import { CriarPlaylistComponent } from './criar-playlist/criar-playlist.component';
import { CriarUsuarioComponent } from './criar-usuario/criar-usuario.component';
import { HomeComponent } from './home/home.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'Home', component: HomeComponent },
    { path: 'CadastroUsuario', component: CriarUsuarioComponent},
    { path: 'CadastroMusicas', component: CadastroMusicaComponent },
    { path: 'CriarPlaylist', component: CriarPlaylistComponent },
    { path: 'Biblioteca', component: BibliotecaComponent },
    { path: 'Favoritas', component: FavoritasComponent },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
