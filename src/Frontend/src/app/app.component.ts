import { Component, OnInit } from '@angular/core';
import { SwUpdate } from '@angular/service-worker';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent implements OnInit {
  
  title = 'Fundacion';

  constructor(private swUpdate: SwUpdate) { }

  ngOnInit(): void {
    this.checkForUpdates();
  }

  checkForUpdates() {
    if (!this.swUpdate.isEnabled) {
      console.log('Service Worker not enabled');
      return;
    }

    // Detectar actualizaciones automáticas
    this.swUpdate.versionUpdates.subscribe(event => {
      //console.log(`Current version: ${event.current}, Available version: ${event.available}`);
      if (confirm('Hay una nueva versión disponible. ¿Desea cargarla?')) {
        this.swUpdate.activateUpdate().then(() => location.reload());
      }
    });
  }
}
