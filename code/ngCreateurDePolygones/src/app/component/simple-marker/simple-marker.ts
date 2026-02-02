import { Component } from '@angular/core';
import { GoogleMap, MapAdvancedMarker, MapMarker } from '@angular/google-maps';

// Interface pour un marqueur avec son style
interface MarkerWithStyle {
  position: google.maps.LatLngLiteral;
  content: HTMLElement;
}

@Component({
  selector: 'app-simple-marker',
  imports: [GoogleMap, MapAdvancedMarker],
  templateUrl: './simple-marker.html',
})
export class SimpleMarker {
  mapOptions: google.maps.MapOptions = {
    mapId: "MON_ID_DE_CARTE"
  };

  // Icônes de marqueurs disponibles
  availableIcons: string[] = [
    '📍',
    '💁‍♀️',
    '💅',
    '🫃',
    '🫦',
  ];

  // Icône actuellement sélectionnée
  selectedIcon: string = this.availableIcons[0];

  // Marqueurs à afficher sur la carte (avec leur style)
  markers: MarkerWithStyle[] = [];

  onClickOnMap(event: google.maps.MapMouseEvent) {
    console.log('Vous avez cliqué sur les coordonnées suivantes : ', '\n\tLat : ', event.latLng?.lat(), '\n\tLng : ', event.latLng?.lng());
    this.addMarker(event);
  }

  addMarker(event: google.maps.MapMouseEvent) {
    this.markers.push({
      position: event.latLng!.toJSON(),
      content: this.createMarkerContent(this.selectedIcon)
    });
  }

  selectIcon(icon: string) {
    this.selectedIcon = icon;
  }

  // Crée un élément HTML pour le marqueur personnalisé
  createMarkerContent(icon: string): HTMLElement {
    const div = document.createElement('div');
    div.style.width = '30px';
    div.style.height = '30px';
    div.style.fontSize = '30px';
    div.style.cursor = 'pointer';
    div.innerText = icon;
    return div;
  }
}
