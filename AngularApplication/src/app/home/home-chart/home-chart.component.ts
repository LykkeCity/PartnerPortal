import { Component, ElementRef, HostListener, OnDestroy, OnInit } from '@angular/core';
import * as echarts from 'echarts';
import { HomeChartService } from './home-chart.service';
import * as moment from 'moment';


const chartSeriesMap = {
  bid: 0,
  ask: 1
};

const timeChartValues = [];

for (let i = 149; i >= 0; i--) {
  timeChartValues.push(moment().subtract(i, 'days').format('DD MMM'));
}

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
      data: timeChartValues
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
              private homeChartService: HomeChartService) { }

  changeChartAsset(assetId: string) {
    this.selectedChartAsset = assetId;
    this.populateChart(assetId);
  }

  populateChart(assetId) {
    this.homeChartService.getChartData(assetId).subscribe(
      data => {
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
