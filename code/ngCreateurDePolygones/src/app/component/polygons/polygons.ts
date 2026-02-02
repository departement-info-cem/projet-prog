import { Component, signal } from '@angular/core';
import { GoogleMap, MapAdvancedMarker, MapPolygon } from '@angular/google-maps';

@Component({
  selector: 'app-polygons',
  imports: [GoogleMap, MapPolygon, MapAdvancedMarker],
  templateUrl: './polygons.html',
  styleUrl: './polygons.scss',
})
export class Polygons {

  mapOptions: google.maps.MapOptions = {
    mapId: "MON_ID_DE_CARTE",
    center: { lat: 25, lng: -71 },
    zoom: 4
  };

  polygonStarted = signal(false);

  // Liste de polygones. C'est un tableau de tableau de coordonées.
  // Fondamentalement, un polygon c'est un liste ordonnées de coordonnées qui sont reliées entre elles. 
  // La dernière coordonnée de la liste est relié à la première pour dessiner une forme
  // Le premier niveau du tableau stocke les polygones.
  // Le deuxième niveau des tableaux stockent les coordonnées des polygones.
  polygons = signal<google.maps.LatLngLiteral[][]>([
    [
      { lat: 32.321, lng: -64.757 },
      { lat: 25.774, lng: -80.190 },
      { lat: 18.466, lng: -66.118 },
    ],
  ]);

  startOfPolygonMarker?: google.maps.LatLngLiteral;

  onClickOnMap(event: google.maps.MapMouseEvent) {
    // S'il n'y a pas de polygone entrain d'être créé, on commence à en créer un nouveau en ajoutant un nouveau tableau de coordonnées à la fin de notre tableau de polygones.
    if (!this.polygonStarted()) {
      this.polygons.update(polygons => [...polygons, []]);
      this.polygonStarted.set(true);
      this.startOfPolygonMarker = { lat: event.latLng!.lat(), lng: event.latLng!.lng() };
    }
    this.addPointToPolygon(event);
  }

  addPointToPolygon(event: google.maps.MapMouseEvent) {
    const newPoint = { lat: event.latLng!.lat(), lng: event.latLng!.lng() };

    this.polygons.update(polygons => {
      const lastIndex = polygons.length - 1;
      return [
        ...polygons.slice(0, lastIndex),
        [...polygons[lastIndex], newPoint]
      ];
    });
  }

  addMarker(event: google.maps.MapMouseEvent) {
    this.startOfPolygonMarker = { lat: event.latLng!.lat(), lng: event.latLng!.lng() };
  }

  /*  Terminer le polygone en cours de création */
  endPolygon() {
    this.polygonStarted.set(false);
    this.startOfPolygonMarker = undefined;
  }

  /*  Retirer le marqueur qui indique la position de départ du polygone */
  removeMarker() {
    this.startOfPolygonMarker = undefined;
  }
}
