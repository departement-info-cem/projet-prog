import { Component } from '@angular/core';
import { SimpleMarker } from "./component/simple-marker/simple-marker";
import { Polygons } from "./component/polygons/polygons";

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  imports: [SimpleMarker, Polygons],
})
export class App {
}
