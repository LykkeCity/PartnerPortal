import { Component, ElementRef, HostListener, OnDestroy, OnInit } from '@angular/core';
import * as echarts from 'echarts';
import * as moment from 'moment';
import { HomeService } from '../home.service';


const chartSeriesMap = {
  bid: 0,
  ask: 1
};

@Component({
  selector: 'lpp-home-chart',
  templateUrl: './home-chart.component.html',
  styleUrls: ['./home-chart.component.scss']
})

export class HomeChartComponent implements OnInit, OnDestroy {

  public selectedChartAsset = 'LKK';


  private chartOptions: echarts.EChartOption = {
    color: ['#33cc8b'],
    tooltip: {
      trigger: 'axis'
    },
    xAxis: {
      axisLine: {
        show: false
      },
      axisTick: {
        show: false
      },
      boundaryGap: false,
      data: []
    },
    yAxis: {
      scale: true,
      axisLine: {
        show: false
      },
      axisTick: {
        show: false
      },
      splitLine: {
        lineStyle: {
          color: ['#f5f6f6'],
          width: 2
        }
      }
    },
    series: [
      {
        showSymbol: false,
        name: 'Bid',
        type: 'line',
        areaStyle: {
          normal: {
            color: '#e8f9f5'
          }
        },
        lineStyle: {
          normal: {
            width: 0.8
          }
        },
        data: []
      },

    ],
    grid: {
      left: 0,
      right: 0,
      containLabel: true

    }
  };

  chart: echarts.ECharts;

  constructor(private elRef: ElementRef,
              private homeService: HomeService) { }

  changeChartAsset(assetId: string) {
    this.selectedChartAsset = assetId;
    this.populateChart(assetId);
  }

  populateChart(assetId) {
    this.homeService.getChartData(assetId).subscribe(
      data => {

        this.chartOptions.xAxis['data'] = this.generateXAxis(data['Result'].EndTime, data['Result'].Rate.AskBidGraph.length);

        this.chartOptions.series[chartSeriesMap.bid]['data'] = [];
        data['Result'].Rate.AskBidGraph.map(
          item => {
            this.chartOptions.series[chartSeriesMap.bid]['data'].push(item.B);
          }
        );
        this.chart.setOption(this.chartOptions);
      }
    );
  }

  generateXAxis(endTime: string, valuesCount: number): Array<string> {

    const timeChartValues = [];
    const firstDay = moment(endTime).subtract(valuesCount, 'days');

    for (let i = 0; i < valuesCount; i++) {
      timeChartValues.push(firstDay.add(1, 'days').format('DD MMM'));
    }
    return timeChartValues;
  }

  ngOnInit() {
    this.chart = echarts.init(this.elRef.nativeElement.querySelector('.chart'));
    this.chart.setOption(this.chartOptions);
    this.populateChart(this.selectedChartAsset);
  }

  ngOnDestroy() {
    this.chart.dispose();
  }

  @HostListener('window:resize', ['$event']) onWindowResize(event: any) {
    this.chart.resize();
  }
}
