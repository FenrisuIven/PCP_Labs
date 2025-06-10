#include <iostream>
#include <cstdlib>
#include <ctime>
#include <omp.h>
#include <tuple>

using namespace std;

const int amount_rows = 20000;
const int amount_cols = 20000;

int arr[amount_rows][amount_cols];

int amount_threads = 8;

void init();
long long all_rows_total_sum(int amount_threads);
tuple<long long, int> min_row_sum(int amount_threads);

int main() {
    omp_set_nested(1);
    init();

    long long total = 0;
    tuple<int, int> min;

    double start = omp_get_wtime();

#pragma omp parallel sections
    {
#pragma omp section
        total = all_rows_total_sum(amount_threads);

#pragma omp section
        min = min_row_sum(amount_threads);
    }

    double end = omp_get_wtime();

    cout << "\n[✓]\tsum:\t" << total << endl;
    cout << "[✓] min sum:\t" << get<0>(min) << " [idx: " << get<1>(min) << "]\n";
    cout << "[i]   total:\t" << end - start << "s" << endl;

    return 0;
}

void init() {
    srand(time(NULL));
    cout << "- Init started";

    double start = omp_get_wtime();
#pragma omp parallel for num_threads(amount_threads)
    for (int i = 0; i < amount_rows; ++i) {
        for (int j = 0; j < amount_cols; ++j) {
            arr[i][j] = rand();
        }
    }
    double end = omp_get_wtime();

    cout << " and finished in " << end - start << "s\n" << endl;
}

long long all_rows_total_sum(int amount_threads) {
    long long sum = 0;

    double start = omp_get_wtime();
#pragma omp parallel for reduction(+:sum) num_threads(amount_threads)
    for (int i = 0; i < amount_rows; ++i) {
        for (int j = 0; j < amount_cols; ++j) {
            sum += arr[i][j];
        }
    }

    double end = omp_get_wtime();

    cout << "[i]\tsum:\t"<< sum << " [" << end - start << "s] " << amount_threads << " threads.\n";
    return sum;
}

tuple<long long, int> min_row_sum(int amount_threads) {
    long long sums[amount_rows];
    double start = omp_get_wtime();

#pragma omp parallel for num_threads(amount_threads)
    for (int i = 0; i < amount_rows; ++i) {
        for (int j = 0; j < amount_cols; ++j) {
            sums[i] += arr[i][j];
        }
    }

    long long min_sum = sums[0];
    int min_idx = 0;

#pragma omp parallel for num_threads(amount_threads)
    for (int i = 0; i < amount_rows; ++i) {
#pragma omp critical
        if (sums[i] < min_sum) {
            min_sum = sums[i];
            min_idx = i;
        }
    }
    double end = omp_get_wtime();

    tuple<long long, int> min = make_tuple(min_sum, min_idx);
    cout << "[i] min sum:\t" << get<1>(min) << " [" << end - start << "s] " << amount_threads << " threads.\n";

    return min;
}