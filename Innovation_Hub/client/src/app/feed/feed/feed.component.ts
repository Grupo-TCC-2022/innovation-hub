import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ItemFilter } from 'src/app/_interfaces/ItemFilter';
import { AccountService } from 'src/app/_services/account.service';
import { InterestAreasService } from 'src/app/_services/interestAreas.service';
import { ProposalsService } from 'src/app/_services/proposals.service';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.css']
})
export class FeedComponent implements OnInit {
  public proposalType: any = "projects";
  obsArray: BehaviorSubject<any[]> = new BehaviorSubject<any[]>([]);
  items$: Observable<any> = this.obsArray.asObservable();
  filterDto: ItemFilter = {
    skip: 0,
    take: 20,
  }
  onFire: boolean = true;
  recents: boolean;

  constructor(public accountService: AccountService, public interestAreasService: InterestAreasService, public proposalsService: ProposalsService) { }

  ngOnInit(): void {
    this.getProjectsScroll();
  }

  onProjectsTab() {
    this.filterDto.skip = 0;
    this.obsArray.next([]);
    this.proposalType = "projects";
    this.getProjectsScroll();
    console.log("Projects");
  }

  onIdeasTab() {
    this.filterDto.skip = 0;
    this.obsArray.next([]);
    this.proposalType = "ideas";
    this.getIdeasScroll();
    console.log("Ideas");
  }

  onProblemsTab() {
    this.filterDto.skip = 0;
    this.obsArray.next([]);
    this.proposalType = "problems";
    this.getProblemsScroll();
    console.log("Problems");
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

  onProposalsScroll(event: any) {
    // visible height + pixel scrolled >= total height 
    if (event.target.offsetHeight + event.target.scrollTop >= event.target.scrollHeight) {
      console.log("End");
      if (this.proposalType == "projects") {
        this.getProjectsScroll();
      } else if (this.proposalType == "ideas") {
        this.getIdeasScroll();
      } else if (this.proposalType == "problems") {
        this.getProblemsScroll();
      }
    }
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
