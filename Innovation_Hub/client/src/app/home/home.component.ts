import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, forkJoin, Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { ItemFilter } from '../_interfaces/ItemFilter';
import { AccountService } from '../_services/account.service';
import { InterestAreaService } from '../_services/interest-area.service';
import { InterestAreasService } from '../_services/interestAreas.service';
import { ProposalsService } from '../_services/proposals.service';
import { faArrowCircleUp as arrowSolid } from '@fortawesome/free-solid-svg-icons';
import { faArrowAltCircleUp as arrowRegular } from '@fortawesome/free-regular-svg-icons';
import { faStar as starFavoriteSolid } from '@fortawesome/free-solid-svg-icons';
import { faStar as starFavoriteRegular } from '@fortawesome/free-regular-svg-icons';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public proposalType: any = "projects";
  obsArray: BehaviorSubject<any[]> = new BehaviorSubject<any[]>([]);
  items$: Observable<any> = this.obsArray.asObservable();
  filterDto: ItemFilter = {
    skip: 0,
    take: 20,
  }
  onFire: boolean = true;
  recents: boolean;

  arrowSolid = arrowSolid;
  arrowRegular = arrowRegular;
  starFavoriteSolid = starFavoriteSolid;
  starFavoriteRegular = starFavoriteRegular;

  constructor(public accountService: AccountService, public interestedAreasService: InterestAreasService, public proposalsService: ProposalsService, public interestAreaService: InterestAreaService) { }

  toggleVote(event: any) {
    console.log(alert("Faça login"));
    //A fazer
  }

  setCategory(value: any) {
    this.filterDto.category = value;
    this.filterDto.skip = 0;
    this.obsArray.next([]);
    console.log(value);
    if (this.proposalType == "ideas") {
      this.getIdeasScroll();
    } else if (this.proposalType == "projects") {
      this.getProjectsScroll();
    } else if (this.proposalType == "problems") {
      this.getProblemsScroll();
    }
  }

  toggleRadios(value) {
    if (value == "1") {
      this.recents = false;
      this.onFire = true;
    } else if (value = "2") {
      this.onFire = false;
      this.recents = true;
    }
    switch (this.proposalType) {
      case "projects":
        this.filterDto.skip = 0;
        this.obsArray.next([]);
        this.getProjectsScroll();
        break;
      case "ideas":
        this.filterDto.skip = 0;
        this.obsArray.next([]);
        this.getIdeasScroll();
        break;
      case "problems":
        this.filterDto.skip = 0;
        this.obsArray.next([]);
        this.getProblemsScroll();
        break;
      default:
        break;
    }
  }

  onProjectsTab() {
    this.filterDto.skip = 0;
    this.obsArray.next([]);
    this.proposalType = "projects";
    this.getProjectsScroll();
  }

  onIdeasTab() {
    this.filterDto.skip = 0;
    this.obsArray.next([]);
    this.proposalType = "ideas";
    this.getIdeasScroll();
  }

  onProblemsTab() {
    this.filterDto.skip = 0;
    this.obsArray.next([]);
    this.proposalType = "problems";
    this.getProblemsScroll();
  }

  onProjectsScroll(event: any) {
    // visible height + pixel scrolled >= total height 
    if (event.target.offsetHeight + event.target.scrollTop >= event.target.scrollHeight) {
      console.log("End");
      this.getProjectsScroll();
    }
  }

  onIdeasScroll(event: any) {
    // visible height + pixel scrolled >= total height 
    if (event.target.offsetHeight + event.target.scrollTop >= event.target.scrollHeight) {
      console.log("End");
      this.getIdeasScroll();
    }
  }

  onProblemsScroll(event: any) {
    // visible height + pixel scrolled >= total height 
    if (event.target.offsetHeight + event.target.scrollTop >= event.target.scrollHeight) {
      console.log("End");
      this.getProblemsScroll();
    }
  }

  getProjectsScroll() {
    const filter = this.turnFilterIntoUrl(this.filterDto);

    if (this.filterDto.skip == 0) {
      this.filterDto.skip += 20;
    }

    this.proposalsService.getProjectsScroll(filter).subscribe((response: any) => {
      const currentValue = this.obsArray.value;
      let updatedValue;
      if (currentValue.length > 0) {
        updatedValue = [...currentValue, response];
        updatedValue = [].concat.apply([], updatedValue)
      } else {
        updatedValue = response;
      }
      console.log(updatedValue);
      this.obsArray.next(updatedValue);
    }, error => {
      console.log(error);
    });
  }

  getIdeasScroll() {
    const filter = this.turnFilterIntoUrl(this.filterDto);

    if (this.filterDto.skip == 0) {
      this.filterDto.skip += 20;
    }

    this.proposalsService.getIdeasScroll(filter).subscribe((response: any) => {
      const currentValue = this.obsArray.value;
      let updatedValue;
      if (currentValue.length > 0) {
        updatedValue = [...currentValue, response];
        updatedValue = [].concat.apply([], updatedValue)
      } else {
        updatedValue = response;
      }
      console.log(updatedValue);
      this.obsArray.next(updatedValue);
    }, error => {
      console.log(error);
    });
  }

  getProblemsScroll() {
    const filter = this.turnFilterIntoUrl(this.filterDto);

    if (this.filterDto.skip == 0) {
      this.filterDto.skip += 20;
    }

    this.proposalsService.getProblemsScroll(filter).subscribe((response: any) => {
      const currentValue = this.obsArray.value;
      let updatedValue;
      if (currentValue.length > 0) {
        updatedValue = [...currentValue, response];
        updatedValue = [].concat.apply([], updatedValue)
      } else {
        updatedValue = response;
      }
      console.log(updatedValue);
      this.obsArray.next(updatedValue);
    }, error => {
      console.log(error);
    });
  }

  ngOnInit(): void {
    this.getProjectsScroll();
  }

  turnFilterIntoUrl(filterDto?: ItemFilter) {
    if (filterDto.skip != 0) {
      filterDto.skip += 20;
    }

    if (this.onFire) {
      filterDto.orderBy = "votes";
    } else if (this.recents) {
      filterDto.orderBy = "recents";
    }

    let urlFilter = '?';

    for (const [key, value] of Object.entries(filterDto)) {
      urlFilter += `${key}=${value}&`;
    }

    return urlFilter.substring(0, urlFilter.length - 1);
  }
}
