import { Component } from '@angular/core';
import { GoogleMap, MapAdvancedMarker, MapMarker } from '@angular/google-maps';

@Component({
  selector: 'app-simple-marker',
  imports: [GoogleMap, MapAdvancedMarker],
  templateUrl: './simple-marker.html',
})
export class SimpleMarker {
  mapOptions: google.maps.MapOptions = {
    mapId: "MON_ID_DE_CARTE"
  };

  // Marqueurs à afficher sur la carte
  markerPositions: google.maps.LatLngLiteral[] = [];

  onClickOnMap(event: google.maps.MapMouseEvent) {
    console.log('Vous avez cliqué sur les coordonnées suivantes : ', '\n\tLat : ', event.latLng?.lat(), '\n\tLng : ', event.latLng?.lng());
    this.addMarker(event);
  }

  addMarker(event: google.maps.MapMouseEvent) {
    this.markerPositions.push(event.latLng!.toJSON());
  }
}
